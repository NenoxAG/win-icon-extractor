import os from 'os';
import { exec } from 'node:child_process';

export async function getIcon(path) {
    if (os.type() === "Windows_NT") {

        if(!path)
            throw new Error('No path provided.');

        const icon = await new Promise((resolve, reject) => {
            exec(`win-icon-extractor.exe "${path}"`, (err, stdout, stderr) => {
                if (err)
                    return reject(new Error(err));
                if(stderr)
                    return reject(new Error(stderr));
                resolve(stdout);
            });
        });

        return icon;

    } else {
        throw new Error('Operating system not supported.');
    }
}