# Advent of Code

Attempt at [Advent of Code](https://adventofcode.com/) using F#. 

## How to run

There are two ways to get the solution for a day's puzzle: Using `dotnet run` or F#'s interactive shell `dotnet fsi` (or shortcuts like `alt+enter` in VSCode's Ionide Plugin).

### dotnet fsi

Run year 2022, day 7:

```shell
dotnet fsi Year2022/Day09.fsx
```

### dotnet run

From root folder (this folder): 

```shell
dotnet run --project CLI -- <year> <day>
```

(**Note the space after `--` before `<year> <day>`**).

Run year 2022, day 7:

```shell
dotnet run --project CLI -- 2022 7
```
