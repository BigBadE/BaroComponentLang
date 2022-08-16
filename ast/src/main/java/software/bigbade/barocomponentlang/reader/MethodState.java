package software.bigbade.barocomponentlang.reader;

import software.bigbade.barocomponentlang.tree.Program;

public class MethodState implements ReaderState {
    private boolean done = false;
    private int depth = 0;

    @Override
    public int read(Program program, char[] characters, int index, int end) {

        return 0;
    }

    @Override
    public ReaderState nextState() {
        return done ? new MainState() : this;
    }
}
