import React, { Component } from "react";
import "./TableRow.css";
import { Glyphicon, Modal, Button } from "react-bootstrap";
import { cellDataTranslate } from "../services/TranslationService";
import { confirmAlert } from "react-confirm-alert";
import "react-confirm-alert/src/react-confirm-alert.css";
import EditForm from "./EditForm.jsx";
import SplitForm from "./SplitForm.jsx";

class TableRow extends Component {
  state = {
    showDeleteForm: false,
    showEditForm: false,
    showSplitForm: false,
    showReleaseForm: false,
    showBonusForm: false
  };

  renderRow() {
    const { rowData } = this.props;
    const rowKeys = Object.keys(rowData);
    const cells = [];
    rowKeys.forEach(key => {
      cells.push(
        <td key={rowKeys.indexOf(key)}>
          {cellDataTranslate(key, rowData[key])}
        </td>
      );
    });
    return cells;
  }

  setEditFormVisible = value => {
    this.setState({ showEditForm: value });
  };

  setSplitFormVisible = value => {
    this.setState({ showSplitForm: value });
  };

  renderSplitComposite = () => {
    return this.props.currentlyLoaded === "Cultivation" ? (
      <td>
        <Glyphicon
          glyph="glyphicon glyphicon-scissors"
          onClick={() => {
            this.setState({ showSplitForm: true });
          }}
        />
        <SplitForm
          visible={this.state.showSplitForm}
          setSplitFormVisible={this.setSplitFormVisible}
          acreage={this.props.rowData["acreage"]}
          id={this.props.rowData["id"]}
          splitCultivation={this.props.splitCultivation}
        />
      </td>
    ) : null;
  };

  renderReleaseMachine = () => {
    return this.props.currentlyLoaded === "Machine" ? (
      <td>
        <Glyphicon
          glyph="glyphicon glyphicon-globe"
          onClick={() => {
            this.setState({ showReleaseForm: true });
          }}
        />
        {this.state.showReleaseForm
          ? confirmAlert({
              title: "Potwierdzenie zwolnienia",
              message:
                "Czy na pewno chcesz zwolnić maszynę #" +
                this.props.rowData["id"] +
                "?",
              buttons: [
                {
                  label: "Tak",
                  onClick: () => {
                    this.setState({ showReleaseForm: false });
                    this.props.releaseMachine(this.props.rowData.id);
                  }
                },
                {
                  label: "Nie",
                  onClick: () => {
                    this.setState({ showReleaseForm: false });
                  }
                }
              ]
            })
          : null}
      </td>
    ) : null;
  };

  renderRestore = () => {
    const { currentlyLoaded } = this.props;
    return currentlyLoaded === "Summary/list" ? (
      <td>
        <Glyphicon
          glyph="glyphicon glyphicon-fast-backward"
          onClick={() => {
            this.props.restoreState(this.props.rowData["id"]);
          }}
        />
      </td>
    ) : null;
  };

  renderEditRow = () => {
    const { currentlyLoaded } = this.props;
    return currentlyLoaded !== "Stable" &&
      currentlyLoaded !== "Cultivation" &&
      currentlyLoaded !== "Machine" &&
      currentlyLoaded !== "Summary/list" ? (
      <td>
        <Glyphicon
          glyph="glyphicon glyphicon-pencil"
          onClick={() => {
            this.setState({ showEditForm: true });
          }}
        />
        <EditForm
          visible={this.state.showEditForm}
          data={this.props.rowData}
          currentlyLoaded={this.props.currentlyLoaded}
          onClick={() => {
            this.setState({ showEditForm: true });
          }}
          setEditFormVisible={this.setEditFormVisible}
        />
      </td>
    ) : null;
  };

  renderDeleteRow = () => {
    return this.props.currentlyLoaded !== "Cultivation" &&
      this.props.currentlyLoaded !== "Machine" &&
      this.props.currentlyLoaded !== "Stable" &&
      this.props.currentlyLoaded !== "Summary/list" ? (
      <td>
        <Glyphicon
          glyph="glyphicon glyphicon-trash"
          onClick={() => {
            this.props.delete(this.props.rowData["id"]);
          }}
        />
      </td>
    ) : null;
  };

  renderSow = () => {
    return this.props.currentlyLoaded === "Cultivation" ? (
      <td>
        <Glyphicon
          glyph={"glyphicon glyphicon-grain"}
          onClick={() => this.props.handleSow(this.props.rowData["id"])}
        />
      </td>
    ) : null;
  };

  renderHarvest = () => {
    return this.props.currentlyLoaded === "Cultivation" ? (
      <td>
        <Glyphicon
          glyph={"glyphicon glyphicon-remove"}
          onClick={() => this.props.handleHarvest(this.props.rowData["id"])}
        />
      </td>
    ) : null;
  };

  renderBonus = () => {
    return this.props.currentlyLoaded === "Worker" ? (
      <td>
        <Glyphicon
          glyph="glyphicon glyphicon-usd"
          onClick={() => {
            this.setState({ showBonusForm: true });
          }}
        />
        <Modal show={this.state.showBonusForm}>
          <Modal.Header>
            <Modal.Title>Przydziel premię</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Button
              bsStyle="primary"
              onClick={() => {
                this.setState({ showBonusForm: false });
                this.props.bonus(this.props.rowData["id"], "amount");
              }}
            >
              Ilościowa
            </Button>{" "}
            <Button
              bsStyle="primary"
              onClick={() => {
                this.setState({ showBonusForm: false });
                this.props.bonus(this.props.rowData["id"], "percent");
              }}
            >
              Procentowa
            </Button>{" "}
            <Button
              bsStyle="primary"
              onClick={() => {
                this.setState({ showBonusForm: false });
                this.props.bonus(this.props.rowData["id"], "discretionary");
              }}
            >
              Uznaniowa
            </Button>{" "}
            <Button
              bsStyle="danger"
              onClick={() => {
                this.setState({ showBonusForm: false });
                this.props.bonus(this.props.rowData["id"], "Reset");
              }}
            >
              Reset
            </Button>
          </Modal.Body>
        </Modal>
      </td>
    ) : null;
  };

  render() {
    return (
      <tr>
        {this.renderRow()}
        {this.renderReleaseMachine()}
        {this.renderSplitComposite()}
        {this.renderHarvest()}
        {this.renderSow()}
        {this.renderEditRow()}
        {this.renderDeleteRow()}
        {this.renderBonus()}
        {this.renderRestore()}
      </tr>
    );
  }
}

export default TableRow;
