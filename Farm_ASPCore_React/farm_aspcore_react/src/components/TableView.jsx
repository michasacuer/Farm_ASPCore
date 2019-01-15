import React, { Component } from "react";
import {
  Button,
  Modal,
  Form,
  FormControl,
  ControlLabel,
  FormGroup
} from "react-bootstrap";
import FarmTable from "./FarmTable";
import "./TableView.css";
import translate, { cellDataTranslate } from "../services/TranslationService";

class TableView extends Component {
  state = {
    newWorkerData: {},
    showAddWorkerForm: false,
    date: new Date()
  };

  componentDidMount() {
    const newWorkerData = this.state.newWorkerData;
    newWorkerData["farmId"] = 1;
    this.setState({ newWorkerData });
  }

  renderSummary = () => {
    const { summary, currentlyLoaded } = this.props;
    return (
      <ul className="summary list-inline">
        {currentlyLoaded === "Summary/list"
          ? Object.keys(summary)
              .filter(key => key !== "summaryDate")
              .map(key => (
                <li key={key} className="list-inline-item">
                  <strong>
                    {translate(key)}: {cellDataTranslate(key, summary[key])}
                  </strong>
                </li>
              ))
          : null}
      </ul>
    );
  };

  handleAddWorkerSubmit = () => {
    this.setState({ showAddWorkerForm: false });
  };

  handleChange = date => {
    this.setState({ date });
  };

  renderAddWorker = () => {
    return (
      <Modal show={this.state.showAddWorkerForm}>
        <Form onSubmit={this.handleAddWorkerSubmit}>
          <Modal.Header>
            <Modal.Title>DODAJ PRACOWNIKA</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <FormGroup>
              <ControlLabel>Imię</ControlLabel>
              <FormControl />
            </FormGroup>
            <FormGroup>
              <ControlLabel>Nazwisko</ControlLabel>
              <FormControl />
            </FormGroup>
            <FormGroup>
              <ControlLabel>Płaca</ControlLabel>
              <FormControl />
            </FormGroup>
            <FormGroup>
              <ControlLabel>Rola</ControlLabel>
              <FormControl componentClass="select">
                <option value="0">Kierowca</option>
                <option value="1">Farmer</option>
              </FormControl>
            </FormGroup>
          </Modal.Body>
          <Modal.Footer>
            <Button
              bsStyle="primary"
              onClick={() => {
                this.setState({ showAddWorkerForm: false });
              }}
            >
              ANULUJ
            </Button>
            <Button bsStyle="success" type="submit">
              DODAJ
            </Button>
          </Modal.Footer>
        </Form>
      </Modal>
    );
  };

  render() {
    return (
      <div className="table-view">
        <FarmTable
          data={this.props.data}
          currentlyLoaded={this.props.currentlyLoaded}
          releaseMachine={this.props.releaseMachine}
          splitCultivation={this.props.splitCultivation}
          editWorker={this.props.editWorker}
        />
        {this.props.currentlyLoaded === "Worker" ? (
          <Button
            bsStyle="primary"
            onClick={() => {
              this.setState({ showAddWorkerForm: true });
            }}
          >
            Dodaj pracownika
          </Button>
        ) : null}
        {this.props.currentlyLoaded === "Machine" ? (
          <Button bsStyle="primary" onClick={this.props.acquireMachine}>
            Zajmij maszynę
          </Button>
        ) : null}
        {this.renderAddWorker()}
        {this.renderSummary()}
        {this.props.currentlyLoaded === "Summary/list" ? (
          <Button bsStyle="primary" onClick={this.props.saveState}>
            Zapisz stan
          </Button>
        ) : null}
      </div>
    );
  }
}

export default TableView;
