package org.markusbrammer.adventofcode.common;

public enum Part {
    ONE,
    TWO;

    @Override
    public String toString() {
        return switch (this) {
            case ONE -> "1";
            case TWO -> "2";
        };
    }
}
