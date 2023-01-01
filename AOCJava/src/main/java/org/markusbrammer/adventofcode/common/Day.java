package org.markusbrammer.adventofcode.common;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.net.URL;
import java.nio.file.Files;

public abstract class Day {
    protected final int year;
    protected final int day;

    protected boolean useExampleInput;

    public Day(int year, int day) {
        this.year = year;
        this.day = day;
        this.useExampleInput = false;
    }

    protected abstract Solution solve(String input);

    public Solution getSolution() throws FileNotFoundException {
        String input = this.getInputFileAsString();
        return this.solve(input);
    }

    public void printSolution() {
        System.out.println("Year " + this.year + ", day " + day);

        Solution solution;
        try {
            solution = this.getSolution();
        } catch (FileNotFoundException e) {
            System.out.println("No solution: " + e.getMessage());
            return;
        }

        printPartResult(Part.ONE, solution);
        printPartResult(Part.TWO, solution);
        System.out.println();
    }

    public void solveUsingExampleInput() {
        this.useExampleInput = true;
    }

    private void printPartResult(Part part, Solution solution) {
        Object result = solution.getResult(part);
        String message = String.format("Part %s: %s", part, result);
        System.out.println(message);
    }

    protected File getInputFile() throws FileNotFoundException {
        // Ensure 1 is "01" and 13 is "13".
        String dayString = String.format("%02d", day);

        // Get input file path from Maven resources folder.
        String inputDirectory = year + (useExampleInput ? "/example" : "") + "/day" + dayString + ".txt";
        URL resource = this.getClass().getClassLoader().getResource(inputDirectory);
        if (resource == null) {
            String errorMessage = "The file " + inputDirectory + " could not be found.";
            throw new FileNotFoundException(errorMessage);
        }

        return new File(resource.getPath());
    }

    protected String getInputFileAsString() throws FileNotFoundException {
        File file = getInputFile();

        try {
            return  Files.readString(file.toPath());
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

}
