package org.markusbrammer.adventofcode.common;

import org.markusbrammer.adventofcode.utils.InputReader;

import java.io.File;
import java.io.FileNotFoundException;

public abstract class Day {
    // Date
    protected int year;
    protected int day;

    // The input that part 1 and 2 uses to solve.
    protected File inputFile;

    public Day(int year, int day, boolean runOnExampleInput) throws FileNotFoundException {
        this.year = year;
        this.day = day;
        this.inputFile = InputReader.getInputFile(year, day, runOnExampleInput);
    }

    abstract public String solvePart1();

    abstract public String solvePart2();

    public void printSolutions() {
        printPartSolution(1, solvePart1());
        printPartSolution(2, solvePart2());
    }

    private void printPartSolution(int part, String result) {
        String message = String.format("Solution to day %d/%d part %d: %s", this.day, this.year, part, result);
        System.out.println(message);
    }
}
