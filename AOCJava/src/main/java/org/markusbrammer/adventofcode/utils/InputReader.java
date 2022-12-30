package org.markusbrammer.adventofcode.utils;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.net.URL;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Collections;
import java.util.List;

public class InputReader {
    public static File getInputFile(int year, int day, boolean getExampleInput) throws FileNotFoundException {
        String dayString = getDayString(day);

        // Get input file path from Maven resources folder.
        String inputDirectory = year + (getExampleInput ? "/example" : "") + "/day" + dayString + ".txt";
        URL resource = InputReader.class.getClassLoader().getResource(inputDirectory);
        if (resource == null) {
            throw new FileNotFoundException();
        }

        return new File(resource.getPath());
    }

    public static List<String> getInputLines(File file) {
        try {
            Path path = file.toPath();
            return Files.readAllLines(path);
        } catch (IOException e) {
            return Collections.emptyList();
        }
    }

    private static String getDayString(int day) {
        return String.format("%02d", day);
    }

    public static File getInputFile(int year, int day) throws FileNotFoundException {
        return getInputFile(year, day, false);
    }

}
