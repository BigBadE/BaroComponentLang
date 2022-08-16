package software.bigbade.barocomponentlang;

import com.google.gson.Gson;
import org.junit.jupiter.api.Test;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.util.Map;

public class ASTTester {

    @Test
    public void test() throws IOException {
        File folder = new File(getClass().getClassLoader().getResource("tests").getFile());
        Gson gson = new Gson();
        for(File test : folder.listFiles()) {
            Map<?, ?> map = gson.fromJson(Files.newBufferedReader(test.toPath()), Map.class);

        }
    }
}
