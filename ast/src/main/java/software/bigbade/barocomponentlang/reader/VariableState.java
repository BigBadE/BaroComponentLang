package software.bigbade.barocomponentlang.reader;

import software.bigbade.barocomponentlang.tree.Program;
import software.bigbade.barocomponentlang.tree.Value;
import software.bigbade.barocomponentlang.util.ParseUtil;

public class VariableState implements ReaderState {

    @Override
    public int read(Program program, char[] characters, int index, int end) {
        String testing = ParseUtil.RemoveSemicolon(characters, index, end);
        if(testing.contains(" = ")) {
            String[] split = testing.split(" = ");
            program.variables.put(split[0], Value.Parse(split[1]));
        } else {
            program.variables.put(testing, null);
        }
        return end - index;
    }

    @Override
    public ReaderState nextState() {
        return new MainState();
    }
}
