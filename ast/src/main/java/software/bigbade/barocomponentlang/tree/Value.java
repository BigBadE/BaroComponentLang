package software.bigbade.barocomponentlang.tree;

public class Value<T> {
    public final T value;

    public Value(T value) {
        this.value = value;
    }

    public static Value<?> Parse(String value) {
        //TODO
        return new Value<>(0);
    }
}
