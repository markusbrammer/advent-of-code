# Advent of Code

Attempting [Advent of Code 2022](https://adventofcode.com/2022) using F#. 

Structure inspired by: [CameronAavik/AdventOfCode](https://github.com/CameronAavik/AdventOfCode). 

## How to run

From root folder (this folder): 

```bash
dotnet run --project Year2022/Year2022.fsproj -- <args>
```

(**Note `--` before `<args>`**). Or inside a `Year` folder: 

```bash
dotnet run -- <args>
```

### Arguments/flags 

- `-a`: Get all solutions. 
- `-e <day> <part>`: Run on example input, day <day> part <part>. 
- `<day>`: Get both results from a day. 
- `<day> <part>`: Get result from day <day> part <part>.

Examples 

- All solutions from 2022: `dotnet run --project Year2022/Year2022.fsproj -- -a`
- Has already cd'ed into a `Year` directory, wants to test implementation of day 3, part 2 on example input: `dotnet run -- -e 3 2`. 