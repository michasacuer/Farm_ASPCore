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
  }

  handleSubmit = e => {
    console.log(this.state.fieldsData);
    this.props.setEditFromVisible(false);
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
              .filter(key => key !== "id")
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
          </Modal.Body>
          <Modal.Footer>
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
