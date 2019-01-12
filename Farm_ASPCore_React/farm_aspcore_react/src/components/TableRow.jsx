import React, { Component } from "react";
import "./TableRow.css";
import { Glyphicon } from "react-bootstrap";
import { confirmAlert } from "react-confirm-alert";
import "react-confirm-alert/src/react-confirm-alert.css";
import EditForm from "./EditForm.jsx";

class TableRow extends Component {
  state = {
    showDeleteForm: false,
    showEditForm: false
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

  render() {
    return (
      <tr>
        {this.renderRow()}
        <td>
          {/* eslint-disable-next-line */}
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
          {/* eslint-disable-next-line */}
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
                      alert("Yes");
                      this.setState({ showDeleteForm: false });
                    }
                  },
                  {
                    label: "Nie",
                    onClick: () => {
                      alert("No");
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
