package com.dma.controleur;

import java.time.format.DateTimeFormatter;
import com.dma.modele.metier.AgendaMedecinJour;
import com.dma.modele.metier.CreneauMedecinJour;
import com.dma.controleur.Mediateur.Contr;
import javafx.beans.binding.Bindings;
import javafx.beans.property.SimpleStringProperty;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TableCell;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.Pane;
import javafx.util.Callback;

public class RdvJourControleur extends AbstractControleur {
		
		@FXML private Pane pane;
		@FXML private Label labelMedecin;
		@FXML private Label labelJour;
		@FXML private Button boutonAccueil;
		@FXML private TableView<CreneauMedecinJour> tableViewAgenda;
		@FXML private TableColumn<CreneauMedecinJour, String> creneauTableColumn;
		@FXML private TableColumn<CreneauMedecinJour, String> patientTableColumn;
		@FXML private TableColumn<CreneauMedecinJour, String> actionTableColumn;
		
		private ObservableList<CreneauMedecinJour> ol_creneaux;
		
		public RdvJourControleur(){
			super(Contr.RDVJOUR);
		}
		
		@FXML private void initialize() {
			boutonAccueil.setOnAction(evt -> super.afficheAgenda());
			
			// le nom du médecin est affiché
			labelMedecin.textProperty().bind(getModele().medecinProperty().asString());
			
			// le jour sélectionné est affiché
			DateTimeFormatter dtf = DateTimeFormatter.ofPattern("dd MMM yyyy");
			labelJour.textProperty().bind(Bindings.createStringBinding(() ->
			    dtf.format(getModele().jourProperty().getValue()), getModele().jourProperty())
			);
	    }
		
		@Override
		public void actualiser(){
			
			AgendaMedecinJour agendaMedecinJour = getService().getAgendaMedecinJour(
					getModele().medecinProperty().getValue(), toDate(getModele().jourProperty().getValue()));
			CreneauMedecinJour[] creneaux = agendaMedecinJour.getCreneauxMedecinJour();
			ol_creneaux = FXCollections.observableArrayList(creneaux);
			//tableViewAgenda.getSelectionModel().setCellSelectionEnabled(true); // autorise la sélection individuelle des cellules
			tableViewAgenda.getItems().setAll(ol_creneaux);
			
			creneauTableColumn.setCellValueFactory(cellData -> new SimpleStringProperty(cellData.getValue().getCreneau().toString()));
			
			patientTableColumn.setCellValueFactory(
					cellData -> cellData.getValue().getRv() != null ? new SimpleStringProperty(cellData.getValue().getRv().getClient().toString()) : new SimpleStringProperty(""));
            
			actionTableColumn.setCellValueFactory(
            		cellData -> cellData.getValue().getRv() != null ? new SimpleStringProperty("Annuler") : new SimpleStringProperty("Réserver"));
        	
			Callback<TableColumn<CreneauMedecinJour, String>, TableCell<CreneauMedecinJour, String>> actionCellFactory = 
					new Callback<TableColumn<CreneauMedecinJour, String>, TableCell<CreneauMedecinJour, String>>() {
                		public TableCell<CreneauMedecinJour, String> call(TableColumn<CreneauMedecinJour, String> p) {
                			TableCell<CreneauMedecinJour, String> cell = new TableCell<CreneauMedecinJour, String>() {
                				@Override
                				public void updateItem(String action, boolean empty) {
		                            super.updateItem(action, empty);
		                            if (empty) {
		                                setText(null);
		                            } else {
		                                setText(action);
		                            }
                				}
                			};
                			
                			cell.addEventHandler(MouseEvent.MOUSE_CLICKED, new EventHandler<MouseEvent>() {
	                         @Override
	                         public void handle(MouseEvent event) {
	                             if (event.getClickCount() > 1) {
	                                 System.out.println("double click on "+ cell.getIndex());
	                             
	                                 AgendaMedecinJour agendaMedecinJour = getService().getAgendaMedecinJour(getModele().medecinProperty().getValue(), toDate(getModele().jourProperty().getValue()));
	                         		 CreneauMedecinJour[] creneaux = agendaMedecinJour.getCreneauxMedecinJour();
	                         		 CreneauMedecinJour creneauMedecinJour = creneaux[cell.getIndex()];
	                         		 getModele().creneauMedecinJourProperty().setValue(creneauMedecinJour);
	                                 
	                         		 affichePriseRdv();
	                             }
	                         }
                		});
                		return cell ;
                	}
            };    
            actionTableColumn.setCellFactory(actionCellFactory);
            
		}
		
		public Pane getPane() {
			return pane;
		}
		
}
