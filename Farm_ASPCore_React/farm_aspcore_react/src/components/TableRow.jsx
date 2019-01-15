import React, { Component } from "react";
import "./TableRow.css";
import { Glyphicon } from "react-bootstrap";
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
    showReleaseForm: false
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

  renderEditRow = () => {
    const { currentlyLoaded } = this.props;
    return currentlyLoaded !== "Stable" &&
      currentlyLoaded !== "Cultivation" &&
      currentlyLoaded !== "Machine" ? (
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
      this.props.currentlyLoaded !== "Machine" ? (
      <td>
        <Glyphicon
          glyph="glyphicon glyphicon-trash"
          onClick={() => {
            this.setState({ showDeleteForm: true });
          }}
        />
        {this.state.showDeleteForm
          ? confirmAlert({
              title: "Potwierdzenie usunięcia",
              message: "Czy na pewno chcesz usunąć rekord?",
              buttons: [
                {
                  label: "Tak",
                  onClick: () => {
                    this.setState({ showDeleteForm: false });
                  }
                },
                {
                  label: "Nie",
                  onClick: () => {
                    this.setState({ showDeleteForm: false });
                  }
                }
              ]
            })
          : null}
      </td>
    ) : null;
  };

  render() {
    return (
      <tr>
        {this.renderRow()}
        {this.renderReleaseMachine()}
        {this.renderSplitComposite()}
        {this.renderEditRow()}
        {this.renderDeleteRow()}
      </tr>
    );
  }
}

export default TableRow;
