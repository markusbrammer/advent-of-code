package org.markusbrammer.adventofcode.common;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.io.File;
import java.io.FileNotFoundException;

import static org.junit.jupiter.api.Assertions.*;

class DayTest {

    private Day validDay;
    private Day invalidDay;

    private final int YEAR = 2022;
    private final int VALID_DAY = 8;
    private final int INVALID_DAY = 26;

    @BeforeEach
    void setUp() {
        this.validDay = new Day(YEAR, VALID_DAY) {
            @Override
            protected Solution solve(String input) {
                return null;
            }
        };

        this.invalidDay = new Day(YEAR, INVALID_DAY) {
            @Override
            protected Solution solve(String input) {
                return null;
            }
        };
    }

    @Test
    void readInputFindsInput() throws FileNotFoundException {
        File file = validDay.getInputFile();
        String path = file.getAbsolutePath();
        assertTrue(path.endsWith("2022/day08.txt"));
    }

    @Test
    void readInputCannotFindAFileWhichDoesNotExist() {
        assertThrows(FileNotFoundException.class, () -> invalidDay.getInputFile());
    }
}