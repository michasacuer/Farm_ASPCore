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

  render() {
    return (
      <tr>
        {this.renderRow()}
        <td>
          {/* eslint-disable-next-line */}
          <Glyphicon glyph="glyphicon glyphicon-pencil" />
        </td>
        <EditForm visible={this.state.showEditForm} />
        <td>
          {/* eslint-disable-next-line */}
          <Glyphicon
            glyph="glyphicon glyphicon-trash"
            onClick={() => {
              this.setState({ showDeleteForm: true });
            }}
          />
        </td>
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
      </tr>
    );
  }
}

export default TableRow;
