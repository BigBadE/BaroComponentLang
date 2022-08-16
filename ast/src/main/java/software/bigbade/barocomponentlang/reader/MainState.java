package software.bigbade.barocomponentlang.reader;

import software.bigbade.barocomponentlang.exceptions.ReaderException;
import software.bigbade.barocomponentlang.tree.Program;

public class MainState implements ReaderState {
    private ReaderState next = this;

    @Override
    public int read(Program program, char[] characters, int index, int end) {
        if(end > 8 && checkChars(characters, index, "func ")) {
            next = new MethodState();
            return 5;
        } else if(end > 5 && checkChars(characters, index, "var ")) {
            next = new VariableState();
            return 4;
        } else if(end > 6 && containsChars(characters, index, end, " -> ")) {
            next = new ListenerState();
            return 0;
        }
        throw new ReaderException("");
    }

    private boolean containsChars(char[] chars, int index, int end, String checking) {
        int pos = 0;
        for(int i = index; i < end; i++) {
            if(chars[index] == checking.charAt(pos++)) {
                if(pos == checking.length()) {
                    return true;
                }
            } else {
                pos = 0;
            }
        }
        return false;
    }

    private boolean checkChars(char[] chars, int index, String checking) {
        for (int i = 0; i < checking.length(); i++) {
            if(chars[i + index] != checking.charAt(i)) {
                return false;
            }
        }
        return true;
    }

    @Override
    public ReaderState nextState() {
        return next;
    }
}
