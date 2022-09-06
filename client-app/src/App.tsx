import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
// import { ducks } from "./demo";
// import DuckItem from "./DuckItem";
import axios from "axios";
import { Header, List } from "semantic-ui-react";

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5000/api/activities").then((response) => {
      setActivities(response.data);
    });
  }, []); // [] dependency will avoid infinite loop

  return (
    <div>
      <Header as="h2" icon="users" content="ActivitiesApp" />

      {/* {ducks.map((duck) => (
          <DuckItem key={duck.name} duck={duck} />
        ))} */}
      <List>
        {activities.map((act: any) => (
          <List.Item key={act.id}>{act.title}</List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
