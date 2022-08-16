package software.bigbade.barocomponentlang.tree;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Program {
    public Map<String, String> listeners = new HashMap<>();
    public List<Value<?>> constants = new ArrayList<>();
    public Map<String, Value<?>> variables = new HashMap<>();
    public List<Method> methods = new ArrayList<>();
}
