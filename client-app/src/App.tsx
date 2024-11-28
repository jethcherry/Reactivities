import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";
import Activity from "./Models/activityModel";
import { Header, List } from "semantic-ui-react";

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios
      .get("http://localhost:5000/api/activities")
      .then((response) => {
        setActivities(response.data);
      })
      .catch(() => {
        console.error("Errror fetching activities");
      });
  }, []);

  return (
    <div>
      <Header as="h2" icon="users" content="Reactivites" />
      <ul>
        {activities.map((activity) => (
          <List key={activity.id}>
            <List.Item key={activity.id}>
              {activity.title}
            </List.Item>
            {/* <h2>{activity.title}</h2> */}
            {/* <p>{activity.description}</p>
            <p>Date: {new Date(activity.date).toLocaleDateString()}</p>
            <p>Category:{activity.category}</p>
            <p>
              Location {activity.city},{activity.venue}
            </p> */}
          </List>
        ))}
      </ul>
    </div>
  );
}

export default App;
