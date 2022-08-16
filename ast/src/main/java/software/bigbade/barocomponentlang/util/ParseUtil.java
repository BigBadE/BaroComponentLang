package software.bigbade.barocomponentlang.util;

public class ParseUtil {
    public static String RemoveSemicolon(char[] characters, int index, int end) {
        if(characters[end] == ';') {
            return new String(characters, index, end-index-1);
        }
        return new String(characters, index, end-index);
    }
}
