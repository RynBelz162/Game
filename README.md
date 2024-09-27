# Game
This is a Web Browser game that uses a Football (Soccer) API to dynamically load teams and display their badges. The user will have attempts to guess what the logo is. Think of this as a cheap Wordle clone but using Football (Soccer) badges.

## Tech Stack
- Blazor
- .NET
- Tailwind CSS

## Requirements
Make sure you have the following installed on your machine
- .NET Sdks
- Tailwindcss CLI: `npm install -g tailwindcss`

## To run
- run `cd Game` then `tailwindcss -i ./Styles/app.css -o ./wwwroot/app.css --watch` to initialize a watcher for any CSS changes
- run `dotnet watch`
- navigate to `http://localhost:5288`