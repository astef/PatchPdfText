# PatchPdfText

CLI tool to update text in PDF files

# Usage

Optionally remove the old content using https://github.com/astef/SweepPdfArea.

Then you can put a new text label with this tool:

```
PS> dotnet run -- `
    --input .\input.pdf `
    --output .\output.pdf `
    --text "`ACCEPTED" `
    --font-path $env:LOCALAPPDATA\Microsoft\Windows\Fonts\Roboto-Black.ttf `
    --font-family "Roboto-Black" `
    --font-size 24 `
    --font-color 00FF15 `
    --page 1 `
    --left 249.8 `
    --bottom 349.15 `
    --width 200 `
    --bg-color 33BB55 `
    --bg-opacity 0.6
```

# Development state

This is a not a complete product, but rather a home-made script helper intended for a particular limited case.

If you feel that it can be slightly updated to be helpful in your case as well, then go update it, or submit an issue.

# License

This tool is using itext7 under the hood, so check-out their license: https://github.com/itext/itext7-dotnet/blob/develop/LICENSE.md

In short, you can not distribute the program without commercial license, but you can use it and distribute the PDF files.
