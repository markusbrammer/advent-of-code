package org.markusbrammer.adventofcode.year2022;

import org.javatuples.Pair;
import org.markusbrammer.adventofcode.common.Day;
import org.markusbrammer.adventofcode.common.Solution;

import java.util.Arrays;

public class Day02 extends Day {
    public Day02() {
        super(2022, 2);
    }

    @Override
    protected Solution solve(String input) {
        String[] inputLines = input.split("\n");
        int resultPart1 = solvePartOne(inputLines);
        int resultPart2 = solvePartTwo(inputLines);
        return new Solution(resultPart1, resultPart2);
    }

    private Shape charToShape(char c) {
        return switch (c) {
            case 'A', 'X' -> Shape.ROCK;
            case 'B', 'Y' -> Shape.PAPER;
            case 'C', 'Z' -> Shape.SCISSOR;
            default -> throw new RuntimeException("Unknown shape for " + c);
        };
    }

    private Pair<Shape, Shape> toGame1(String inputLine) {
        Shape opponentChooses = charToShape(inputLine.charAt(0));
        Shape iChoose = charToShape(inputLine.charAt(2));
        return new Pair<>(opponentChooses, iChoose);
    }

    private Outcome getGameOutcome(Pair<Shape, Shape> game) {
        Shape opponentsShape = game.getValue0();
        Shape myShape = game.getValue1();

        if (opponentsShape == myShape) {
            return Outcome.DRAW;
        } else if (opponentsShape.defeats(myShape)) {
            return Outcome.LOSE;
        } else {
            return Outcome.WIN;
        }
    }

    private int getGameScore(Pair<Shape, Shape> game) {
        Shape myShape = game.getValue1();
        Outcome outcome = getGameOutcome(game);
        return myShape.getScore() + outcome.getScore();
    }

    private int solvePartOne(String[] inputLines) {
        return Arrays.stream(inputLines)
                .map(this::toGame1)
                .map(this::getGameScore)
                .reduce(0, Integer::sum);
    }

    // Deduce the score of my shape by opponents shape and desired outcome.
    private int deduceScore(Shape opponentShape, Outcome outcome) {
        return switch (outcome) {
            case DRAW -> opponentShape.getScore();
            case WIN -> (opponentShape.getScore() % 3) + 1;
            case LOSE -> opponentShape.getScore() - 1 == 0 ? 3 :  opponentShape.getScore() - 1;
        };
    }

    private Outcome charToOutcome(char c) {
        return switch (c) {
            case 'X' -> Outcome.LOSE;
            case 'Y' -> Outcome.DRAW;
            case 'Z' -> Outcome.WIN;
            default -> throw new RuntimeException("Unknown outcome for " + c);
        };
    }

    private int getGame2Score(String inputLine) {
        Shape opponentShape = charToShape(inputLine.charAt(0));
        Outcome outcome = charToOutcome(inputLine.charAt(2));

        int myShapeScore = deduceScore(opponentShape, outcome);
        return myShapeScore + outcome.getScore();
    }

    protected int solvePartTwo(String[] inputLines) {
        return Arrays.stream(inputLines)
                .map(this::getGame2Score)
                .reduce(0, Integer::sum);
    }

    private enum Shape {
        ROCK, PAPER, SCISSOR;

        public boolean defeats(Shape other) {
            return (this == ROCK && other == SCISSOR)
                    || (this == PAPER && other == ROCK)
                    || (this == SCISSOR && other == PAPER);
        }

        public int getScore() {
            return switch (this) {
                case ROCK -> 1;
                case PAPER -> 2;
                case SCISSOR -> 3;
            };
        }
    }

    private enum Outcome {
        WIN, LOSE, DRAW;

        public int getScore() {
            return switch (this) {
                case LOSE -> 0;
                case DRAW -> 3;
                case WIN -> 6;
            };
        }
    }
}



