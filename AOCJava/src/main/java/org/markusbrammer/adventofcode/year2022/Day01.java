package org.markusbrammer.adventofcode.year2022;

import org.markusbrammer.adventofcode.common.Day;
import org.markusbrammer.adventofcode.utils.InputReader;

import java.io.FileNotFoundException;
import java.util.Comparator;
import java.util.LinkedList;
import java.util.List;

public class Day01 extends Day {

    private List<String> inventoryList;

    public Day01(boolean runOnExampleInput) throws FileNotFoundException {
        super(2022, 1, runOnExampleInput);
        parse();
    }

    public Day01() throws FileNotFoundException {
        super(2022, 1, false);
        parse();
    }

    private void parse() {
        this.inventoryList = InputReader.getInputLines(this.inputFile);
    }

    @Override
    public String solvePart1() {
        List<List<Integer>> eachElfInventory = separateElvesInventories(this.inventoryList);
        List<Integer> eachElfInventorySum = getInventoryTotalForEachElf(eachElfInventory);

        // stream().max() returns an optional. Unpacks using tip from:
        // https://stackoverflow.com/a/32277566.
        return eachElfInventorySum.stream()
                .max(Comparator.naturalOrder())
                .map(Object::toString)
                .orElse("No solution");
    }

    @Override
    public String solvePart2() {
        List<List<Integer>> eachElfInventory = separateElvesInventories(this.inventoryList);
        List<Integer> eachElfInventorySum = getInventoryTotalForEachElf(eachElfInventory);

        return eachElfInventorySum.stream()
                .sorted(Comparator.reverseOrder())
                .limit(3)
                .reduce(0, Integer::sum)
                .toString();
    }

    private List<List<Integer>> separateElvesInventories(List<String> inventoryList) {
        List<List<Integer>> eachElfInventory = new LinkedList<>();

        List<Integer> currentInventory = new LinkedList<>();
        for (String calorieEntry : inventoryList) {
            if (!calorieEntry.equals("")) {
                int caloricValue = Integer.parseInt(calorieEntry);
                currentInventory.add(caloricValue);
            } else {
                eachElfInventory.add(List.copyOf(currentInventory));
                currentInventory.clear();
            }
        }

        if (!currentInventory.isEmpty())
            eachElfInventory.add(List.copyOf(currentInventory));

        return eachElfInventory;
    }

    private List<Integer> getInventoryTotalForEachElf(List<List<Integer>> eachElfInventory) {
        return eachElfInventory.stream().map(this::getInventorySum).toList();
    }

    private int getInventorySum(List<Integer> inventory) {
        return inventory.stream().reduce(0, Integer::sum);
    }

}
