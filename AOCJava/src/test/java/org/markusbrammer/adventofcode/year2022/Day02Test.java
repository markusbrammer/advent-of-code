package org.markusbrammer.adventofcode.year2022;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.markusbrammer.adventofcode.common.Day;
import org.markusbrammer.adventofcode.common.Part;

import java.io.FileNotFoundException;

import static org.junit.jupiter.api.Assertions.assertEquals;

class Day02Test {

    private Day day;

    @BeforeEach
    void setUp() {
        this.day = new Day02();
    }

    @Test
    void examplePart1() throws FileNotFoundException {
        this.day.solveUsingExampleInput();
        assertEquals(day.getSolution().getResult(Part.ONE), 15);
    }

    @Test
    void part1() throws FileNotFoundException {
        assertEquals(day.getSolution().getResult(Part.ONE), 14264);
    }

    @Test
    void examplePart2() throws FileNotFoundException {
        this.day.solveUsingExampleInput();
        assertEquals(day.getSolution().getResult(Part.TWO), 12);
    }

    @Test
    void part2() throws FileNotFoundException {
        assertEquals(day.getSolution().getResult(Part.TWO), 12382);
    }

}