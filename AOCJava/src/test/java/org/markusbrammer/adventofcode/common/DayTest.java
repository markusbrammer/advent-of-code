package org.markusbrammer.adventofcode.common;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.io.File;
import java.io.FileNotFoundException;

import static org.junit.jupiter.api.Assertions.*;

class DayTest {

    private Day dayExisting;
    private Day dayNotExisting;

    private final int YEAR = 2022;
    private final int VALID_DAY = 8;
    private final int INVALID_DAY = 26;

    @BeforeEach
    void setUp() {
        this.dayExisting = new Day(YEAR, VALID_DAY) {
            @Override
            protected void parse() {

            }

            @Override
            protected String solvePartOne() {
                return null;
            }

            @Override
            protected String solvePartTwo() {
                return null;
            }
        };

        this.dayNotExisting = new Day(YEAR, INVALID_DAY) {
            @Override
            protected void parse() {

            }

            @Override
            protected String solvePartOne() {
                return null;
            }

            @Override
            protected String solvePartTwo() {
                return null;
            }
        };
    }

    @Test
    void readInputFindsInput() throws FileNotFoundException {
        File file = dayExisting.getResource();
        String path = file.getAbsolutePath();
        assertTrue(path.endsWith("2022/day08.txt"));
    }

    @Test
    void readInputCannotFindAFileWhichDoesNotExist() {
        assertThrows(FileNotFoundException.class, () -> dayNotExisting.getResource());
    }
}