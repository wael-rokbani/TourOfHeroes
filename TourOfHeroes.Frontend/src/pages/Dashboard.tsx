import { useContext } from "react";
import { AppContext } from "../AppContext";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faClock } from "@fortawesome/free-regular-svg-icons/faClock";
import { Link } from "react-router-dom";

const Dashboard = () => {
  //const lastViewedHeroes = useContext(AppContext);

  const { lastViewedHeroes, setLastViewedHeroes } = useContext(AppContext);

  const uniqueList = [];
  const map = new Map();
  for (const item of lastViewedHeroes) {
    if (!map.has(item.id)) {
      map.set(item.id, true); // set any value to Map
      uniqueList.push({
        id: item.id,
        name: item.name,
      });
    }
  }

  return (
    <>
      <h2 className="title">
        Last viewed heroes <FontAwesomeIcon icon={faClock} title="Add Hero" />
      </h2>

      <div>
        {uniqueList
          .slice(0, 3)
          .map((item) => (
            <div key={item.id}>
              <Link to={`/Heroes/${item.id}`}>{item.name}</Link>{" "}
            </div>
          ))}
      </div>
    </>
  );
};

export default Dashboard;
