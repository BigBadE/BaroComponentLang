package software.bigbade.barocomponentlang.reader;

import software.bigbade.barocomponentlang.tree.Program;

public interface ReaderState {
    int read(Program program, char[] characters, int index, int end);

    ReaderState nextState();
}
