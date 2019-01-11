import React, { Component } from "react";
import "./FarmNavbar.css";
import { Navbar, Nav, NavItem } from "react-bootstrap";

class FarmNavbar extends Component {
  render() {
    return (
      <Navbar fixedTop>
        <Navbar.Header>
          <Navbar.Brand>Farma</Navbar.Brand>
        </Navbar.Header>
        <Nav>
          <NavItem
            eventKey={1}
            onSelect={() => {
              this.props.fetchNewData("Worker");
            }}
          >
            Pracownicy
          </NavItem>
          <NavItem
            eventKey={2}
            onSelect={() => {
              this.props.fetchNewData("Stable");
            }}
          >
            Zwierzęta
          </NavItem>
          <NavItem
            eventKey={3}
            onSelect={() => {
              this.props.fetchNewData("Cultivation");
            }}
          >
            Uprawy
          </NavItem>
          <NavItem
            eventKey={4}
            onSelect={() => {
              this.props.fetchNewData("Machine");
            }}
          >
            Maszyny
          </NavItem>
          <NavItem
            eventKey={5}
            onSelect={() => {
              this.props.fetchNewData("Memento");
            }}
          >
            Zapisane stany
          </NavItem>
          <NavItem eventKey={6} /*dorobić*/>Rozliczenie</NavItem>
        </Nav>
      </Navbar>
    );
  }
}

export default FarmNavbar;
