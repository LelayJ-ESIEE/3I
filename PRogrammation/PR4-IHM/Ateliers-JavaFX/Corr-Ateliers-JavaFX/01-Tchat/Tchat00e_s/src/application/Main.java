package application;
	
import javafx.application.Application;
import javafx.stage.Stage;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.StackPane;

public class Main extends Application {
	@Override
	public void start(Stage primaryStage) {
		try {
		    primaryStage.setTitle("Bonjour!");

		    //BorderPane root = new BorderPane();
		    StackPane root = new StackPane();
		    
		    Button btn = new Button();
	        btn.setText("Bonjour à tous !");
	        /*
	        btn.setOnAction(new EventHandler<ActionEvent>() {
	            @Override
	            public void handle(ActionEvent event) {
	                System.out.println("Bonjour à tous !");
	            }
	        });
	        */
	        btn.setOnAction(evt -> System.out.println("Bonjour à tous !"));
	        root.getChildren().add(btn);
	        
	        Scene scene = new Scene(root,400,400);
			scene.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
			primaryStage.setScene(scene);
			primaryStage.show();
		} catch(Exception e) {
			e.printStackTrace();
		}
	}
	
	public static void main(String[] args) {
		launch(args);
	}
}
