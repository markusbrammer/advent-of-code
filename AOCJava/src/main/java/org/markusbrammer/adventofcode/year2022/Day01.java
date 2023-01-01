package org.markusbrammer.adventofcode.year2022;

import org.markusbrammer.adventofcode.common.Day;
import org.markusbrammer.adventofcode.common.Solution;

import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

public class Day01 extends Day {

    public Day01() {
        super(2022, 1);
    }

    @Override
    protected Solution solve(String input) {
        List<Integer> inventorySums = this.parse(input);
        int resultPart1 = solvePartOne(inventorySums);
        int resultPart2 = solvePartTwo(inventorySums);
        return new Solution(resultPart1, resultPart2);
    }

    private List<Integer> parse(String input) {
        String[] separatedInventories = input.split("\n\n");
        return Arrays.stream(separatedInventories)
                .map(this::getInventorySum)
                .toList();
    }

    private int getInventorySum(String inventory) {
        String[] calorieEntries = inventory.split("\n");
        return Arrays.stream(calorieEntries)
                .map(Integer::parseInt)
                .reduce(0, Integer::sum);
    }

    private int solvePartOne(List<Integer> inventorySums) {
        return Collections.max(inventorySums);
    }

    protected int solvePartTwo(List<Integer> inventorySums) {
        return inventorySums.stream()
                .sorted(Comparator.reverseOrder())
                .limit(3)
                .reduce(0, Integer::sum);
    }
}
