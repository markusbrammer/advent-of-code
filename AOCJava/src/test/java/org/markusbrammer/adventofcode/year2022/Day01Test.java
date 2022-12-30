package org.markusbrammer.adventofcode.year2022;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.markusbrammer.adventofcode.common.Day;

import java.io.FileNotFoundException;

import static org.junit.jupiter.api.Assertions.assertEquals;

class Day01Test {

    private Day day;

    @BeforeEach
    void setUp() throws FileNotFoundException {
        this.day = new Day01(true);
    }

    @Test
    void examplePart1() {
        assertEquals(day.solvePart1(), "24000");
    }

    @Test
    void examplePart2() {
        assertEquals(day.solvePart2(), "45000");
    }
}