import React, { Component } from "react";
import {
  Modal,
  FormGroup,
  Form,
  FormControl,
  Button,
  ControlLabel
} from "react-bootstrap";
import translate from "../services/TranslationService";

class EditForm extends Component {
  state = { fieldsData: {} };

  componentDidMount() {
    const fieldsData = this.state.fieldsData;
    const keys = Object.keys(this.props.data);
    keys.forEach(key => {
      fieldsData[key] = this.props.data[key];
    });
    fieldsData["kind"] = "Farmer";
  }

  handleSubmit = e => {
    this.props.setEditFormVisible(false);
    e.preventDefault();
  };

  handleChange = e => {
    const fieldsData = this.state.fieldsData;
    fieldsData[e.target.name] = e.target.value;
    this.setState({ fieldsData });
  };

  render() {
    const { data } = this.props;
    const keys = Object.keys(data);
    return (
      <Modal show={this.props.visible}>
        <Form onSubmit={this.handleSubmit}>
          <Modal.Header>
            <Modal.Title>EDYTUJ</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            {keys
              .filter(key => key !== "id" && key !== "kind")
              .map(key => (
                <FormGroup controlId={key} key={key}>
                  <ControlLabel>{translate(key)}</ControlLabel>
                  <FormControl
                    defaultValue={data[key]}
                    onChange={this.handleChange}
                    name={key}
                  />
                </FormGroup>
              ))}
            {this.props.currentlyLoaded === "Worker" ? (
              <FormGroup controlId={"kind"} key={"kind"}>
                <ControlLabel>{translate("kind")}</ControlLabel>
                <FormControl
                  componentClass="select"
                  placeholder="Kind"
                  onChange={this.handleChange}
                  name="kind"
                >
                  <option value="0">Driver</option>
                  <option value="1">Farmer</option>
                </FormControl>
              </FormGroup>
            ) : null}
          </Modal.Body>
          <Modal.Footer>
            <Button
              bsStyle="primary"
              onClick={() => {
                this.props.setEditFormVisible(false);
                this.setState({ fieldsData: data });
              }}
            >
              ANULUJ
            </Button>
            <Button type="submit" bsStyle="success">
              ZATWIERDŹ
            </Button>
          </Modal.Footer>
        </Form>
      </Modal>
    );
  }
}

export default EditForm;
