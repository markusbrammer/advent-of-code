package org.markusbrammer.adventofcode.year2022;

import org.markusbrammer.adventofcode.common.Day;

import java.io.FileNotFoundException;
import java.util.Arrays;
import java.util.Comparator;
import java.util.List;

public class Day01 extends Day {

    private List<Integer> inventorySums;

    public Day01() throws FileNotFoundException {
        super(2022, 1);
    }

    @Override
    protected void parse() throws FileNotFoundException {
        String resourceAsString = this.getResourceAsString();

        String[] separatedInventories = resourceAsString.split("\n\n");
        this.inventorySums = Arrays.stream(separatedInventories)
                .map(this::getInventorySum)
                .toList();

        this.hasParsedInput = true;
    }

    private int getInventorySum(String inventory) {
        String[] calorieEntries = inventory.split("\n");
        return Arrays.stream(calorieEntries)
                .map(Integer::parseInt)
                .reduce(0, Integer::sum);
    }

    @Override
    protected Object solvePartOne() {
        return inventorySums.stream()
                .max(Comparator.naturalOrder())
                .map(Object::toString)
                .orElse("No solution"); // https://stackoverflow.com/a/32277566.
    }

    @Override
    protected Object solvePartTwo() {
        return inventorySums.stream()
                .sorted(Comparator.reverseOrder())
                .limit(3)
                .reduce(0, Integer::sum);
    }

}
