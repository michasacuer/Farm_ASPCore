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
    showAddWorkerForm: false
  };

  componentDidMount() {
    const newWorkerData = this.state.newWorkerData;
    newWorkerData["farmId"] = 1;
    newWorkerData["kind"] = 0;
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

  handleAddWorkerSubmit = e => {
    console.log(this.state.newWorkerData);
    this.props.addWorker(this.state.newWorkerData);
    this.setState({ showAddWorkerForm: false });
    e.preventDefault();
  };

  handleChange = e => {
    const newWorkerData = this.state.newWorkerData;
    newWorkerData[e.target.name] = e.target.value;
    this.setState({ newWorkerData });
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
              <FormControl name="firstName" onChange={this.handleChange} />
            </FormGroup>
            <FormGroup>
              <ControlLabel>Nazwisko</ControlLabel>
              <FormControl name="lastName" onChange={this.handleChange} />
            </FormGroup>
            <FormGroup>
              <ControlLabel>Godziny pracy dziennie</ControlLabel>
              <FormControl
                type="number"
                name="hoursPerDay"
                onChange={this.handleChange}
              />
            </FormGroup>
            <FormGroup>
              <ControlLabel>Dni pracy w miesiącu</ControlLabel>
              <FormControl
                type="number"
                name="daysOfWork"
                onChange={this.handleChange}
              />
            </FormGroup>
            <FormGroup>
              <ControlLabel>Stawka godzinowa</ControlLabel>
              <FormControl
                type="number"
                name="usdPerHour"
                onChange={this.handleChange}
              />
            </FormGroup>
            <FormGroup>
              <ControlLabel>Rola</ControlLabel>
              <FormControl
                type="number"
                name="kind"
                onChange={this.handleChange}
                componentClass="select"
              >
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
          delete={this.props.delete}
          restoreState={this.props.restoreState}
          handleSow={this.props.handleSow}
          handleHarvest={this.props.handleHarvest}
          bonus={this.props.bonus}
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
