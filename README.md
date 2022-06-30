# win-icon-extractor

This package is a simple nodejs package to extract icons from Windows executables.

This package supports the extraction of icons from .exe, .lnk and .url files. It will always return the highest available resolution.

## Usage

To get the icon from a Windows executable, you can use the following function. The output will be a base64 data URL.

```js
const winIconExtractor = require('win-icon-extractor');
await winIconExtractor.getIcon('C:/path/to/file.exe');
```

```js
import { getIcon } from 'win-icon-extractor';
await getIcon('C:/path/to/file.exe');
```
