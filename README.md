# PatchPdfText

CLI tool to update text in PDF files

# Usage

```
PS> dotnet run -- `
    --input .\inc.pdf `
    --output .\out.pdf `
    --text "`$2,0010.00" `
    --font-path C:\Users\astef\AppData\Local\Microsoft\Windows\Fonts\Roboto-Italic.ttf `
    --font-family "Roboto-Italic" `
    --font-size 8 `
    --left 249.8 `
    --bottom 349.15 `
    --width 200 `
    --bg-opacity 0
```

# Development state

This is a not a complete product, but rather a home-made script helper intended for a particular limited case.

If you feel that it can be slightly updated to be helpful in your case as well, then go update it, or submit an issue.

# License

This tool is using itext7 under the hood, so check-out their license: https://github.com/itext/itext7-dotnet/blob/develop/LICENSE.md

In short, you can not distribute the program without commercial license, but you can use it and distribute the PDF files.