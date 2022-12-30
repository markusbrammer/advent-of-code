package org.markusbrammer.adventofcode;

import org.markusbrammer.adventofcode.year2022.Day01;

import java.io.FileNotFoundException;

public class Main {
    public static void main(String[] args) {
        try {
            new Day01().printSolutions();
        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        }
    }
}