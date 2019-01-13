import React, { Component } from "react";
import "./TableRow.css";
import { Glyphicon } from "react-bootstrap";
import { confirmAlert } from "react-confirm-alert";
import "react-confirm-alert/src/react-confirm-alert.css";
import EditForm from "./EditForm.jsx";
import SplitForm from "./SplitForm.jsx";

class TableRow extends Component {
  state = {
    showDeleteForm: false,
    showEditForm: false,
    showSplitForm: false
  };

  renderRow() {
    const { rowData } = this.props;
    const rowKeys = Object.keys(rowData);
    const cells = [];
    rowKeys.forEach(key => {
      cells.push(<td key={rowKeys.indexOf(key)}>{rowData[key]}</td>);
    });
    return cells;
  }

  setEditFromVisible = value => {
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
        />
      </td>
    ) : null;
  };

  render() {
    return (
      <tr>
        {this.renderRow()}
        {this.renderSplitComposite()}
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
            onClick={() => {
              this.setState({ showEditForm: true });
            }}
            setEditFromVisible={this.setEditFromVisible}
          />
        </td>
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
            : ""}
        </td>
      </tr>
    );
  }
}

export default TableRow;
