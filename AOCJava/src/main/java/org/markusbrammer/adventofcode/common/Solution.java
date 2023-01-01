package org.markusbrammer.adventofcode.common;

public class Solution {
    private final Object resultPart1;
    private final Object resultPart2;

    public Solution(Object resultPart1, Object resultPart2) {
        this.resultPart1 = resultPart1;
        this.resultPart2 = resultPart2;
    }

    public Object getResult(Part part) {
        return switch (part) {
            case ONE -> resultPart1;
            case TWO -> resultPart2;
        };
    }
}
