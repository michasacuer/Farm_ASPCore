import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";
import TableView from "./components/TableView";

class Routes extends Component {
  render() {
    return (
      <Switch>
        <Route
          exact
          path="/"
          render={props => (
            <TableView
              {...props}
              data={this.props.data}
              currentlyLoaded={this.props.currentlyLoaded}
            />
          )}
        />
      </Switch>
    );
  }
}

export default Routes;
