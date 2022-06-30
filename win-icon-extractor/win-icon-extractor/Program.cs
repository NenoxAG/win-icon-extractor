using System.Drawing;
using System.Drawing.Icons;
using System.Text;
using System.Text.RegularExpressions;
using ShellLink;

try {
    Console.InputEncoding = Encoding.UTF8;
    Console.OutputEncoding = Encoding.UTF8;
    
    if (args.Length <= 0)
        throw new Exception("No path specified.");
                
    var filePath = args[0];
    
    if(!File.Exists(filePath))
        throw new Exception("Specified path does not exist.");

    // Get the file linked to by the .lnk
    if (filePath.EndsWith(".lnk")) {
        var info = Shortcut.ReadFromFile(filePath);
        var file = info.LinkTargetIDList.Path;
        
        // Only use it if the file exists. Else use the icon of the .lnk
        if (File.Exists(file))
            filePath = file;
    }

    var icon = IconsExtractor.ExtractIconFromFile(filePath);

    // Get the icon of a .url file
    if (filePath.EndsWith(".url")) {
        var content = File.ReadAllText(filePath);
        var reg = new Regex("IconFile=(.*)");
        var match = reg.Match(content);
        icon = new Icon(match.Groups[1].Value.Trim(),new Size(int.MaxValue, int.MaxValue)); // int.MaxValue to always get the highest resolution
    }
    
    var converter = new ImageConverter();
    var data = (byte[])converter.ConvertTo(icon.ToBitmap(), typeof(byte[]));

    Console.WriteLine(Convert.ToBase64String(data));
}
catch (Exception ex) {
    Console.Error.WriteLine(ex.Message);
}