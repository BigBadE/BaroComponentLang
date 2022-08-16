package software.bigbade.barocomponentlang.reader;

import software.bigbade.barocomponentlang.tree.Program;

public class ListenerState implements ReaderState {
    @Override
    public int read(Program program, char[] characters, int index, int end) {
        String line = new String(characters, index, end-index);
        String[] split = line.split(" -> ");
        program.listeners.put(split[0], split[1]);
        return line.length();
    }

    @Override
    public ReaderState nextState() {
        return new MainState();
    }
}
