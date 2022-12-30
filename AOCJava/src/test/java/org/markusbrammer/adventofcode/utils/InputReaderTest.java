package org.markusbrammer.adventofcode.utils;

import org.junit.jupiter.api.Test;

import java.io.File;
import java.io.FileNotFoundException;

import static org.junit.jupiter.api.Assertions.*;

class InputReaderTest {

    @Test
    void readInputFindsInput() throws FileNotFoundException {
        File file = InputReader.getInputFile(2022, 8);
        String path = file.getAbsolutePath();
        System.out.println(path);
        assertTrue(path.endsWith("2022/day08.txt"));
    }

    @Test
    void readInputCannotFindAFileWhichDoesNotExist() {
        assertThrows(FileNotFoundException.class, () -> InputReader.getInputFile(2022, 26));
    }
}