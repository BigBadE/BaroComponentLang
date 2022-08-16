package software.bigbade.barocomponentlang;

import software.bigbade.barocomponentlang.exceptions.ReaderException;
import software.bigbade.barocomponentlang.reader.MainState;
import software.bigbade.barocomponentlang.reader.ReaderState;
import software.bigbade.barocomponentlang.tree.Program;

import java.io.IOException;
import java.io.Reader;

public class ASTGenerator {
    private final Program program = new Program();
    private final char[] characters = new char[2048];

    private ReaderState state = new MainState();

    public ASTGenerator(Reader reader) throws IOException {
        int length = reader.read(characters);
        while (length > 0) {
            int index = 0;
            while (index < length) {
                for(int i = index; i <= length; i++) {
                    if(characters[i] == '\n') {
                        index = state.read(program, characters, index, i) + 1;
                        state = state.nextState();
                        break;
                    } else if(i == length) {
                        if(index == 0) {
                            throw new ReaderException("Line longer than 2048 characters!");
                        }
                        length = reader.read(characters);
                    }
                }
            }
            length = reader.read(characters);
        }
    }
}
