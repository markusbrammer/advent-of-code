package org.markusbrammer.adventofcode.common;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.net.URL;
import java.nio.file.Files;

public abstract class Day {
    // Date
    protected final int year;
    protected final int day;

    protected boolean usingExampleInput;
    protected boolean hasParsedInput;

    public Day(int year, int day) {
        this.year = year;
        this.day = day;
        this.usingExampleInput = false;
        this.hasParsedInput = false;
    }

    protected abstract void parse() throws FileNotFoundException;
    protected abstract String solvePartOne();
    protected abstract String solvePartTwo();

    public String solvePart(Part part) {
        if (!this.hasParsedInput) {
            try {
                this.parse();
            } catch (FileNotFoundException e) {
                return e.getMessage();
            }
        }

        return switch (part) {
            case ONE -> this.solvePartOne();
            case TWO -> this.solvePartTwo();
        };
    }

    public void printResults() {
        System.out.println("Year " + this.year + ", day " + day + "");
        printPartResult(Part.ONE);
        printPartResult(Part.TWO);
        System.out.println();
    }

    private void printPartResult(Part part) {
        String result = this.solvePart(part);
        String message = String.format("Part %s: %s", part, result);
        System.out.println(message);
    }

    public void solveUsingExampleInput() {
        this.usingExampleInput = true;
    }

    protected File getResource() throws FileNotFoundException {
        // Ensure day 1 is "01" and 13 is "13".
        String dayString = String.format("%02d", day);

        // Get input file path from Maven resources folder.
        String inputDirectory = year + (usingExampleInput ? "/example" : "") + "/day" + dayString + ".txt";
        URL resource = this.getClass().getClassLoader().getResource(inputDirectory);
        if (resource == null) {
            String errorMessage = "The file " + inputDirectory + " could not be found.";
            throw new FileNotFoundException(errorMessage);
        }

        return new File(resource.getPath());
    }

    protected String getResourceAsString() throws FileNotFoundException {
        File file = getResource();

        try {
            return  Files.readString(file.toPath());
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

}
