import { useState, useEffect } from "react";
import { Hero, HeroesService } from "../generated";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from "react-router-dom";
import { faEye } from "@fortawesome/free-regular-svg-icons/faEye";
import { faTrashCan } from "@fortawesome/free-regular-svg-icons/faTrashCan";
import { faSquarePlus } from "@fortawesome/free-regular-svg-icons/faSquarePlus";

const HeroesList = () => {
  const [heroes, setHeroes] = useState<Hero[]>([]);

  const loadData = async () => {
    const result = await HeroesService.getApiV1Heroes();
    setHeroes(result);
  };

  useEffect(() => {
    loadData();
  }, []);

  const handleDelete = async (id: number) => {
    if (!window.confirm("You are about to delete a hero, continue ?")) return;

    const result = await HeroesService.deleteApiV1Heroes(id);

    if (result > 0) loadData();
  };

  return (
    <>
      <h2 className="title">
        Heroes List
        <Link to={"/Heroes/New"}>
          {" "}
          <FontAwesomeIcon icon={faSquarePlus} title="Add Hero" />
        </Link>
      </h2>

      <div className="pageContent">
        {heroes.length === 0 ? <span>No Data</span> : ""}

        <div className="heroesList">
          {heroes.map((item) => (
            <div className="heroItem" key={item.id}>
              <div className="actions">
                <Link to={`/Heroes/${item.id}`}>
                  {" "}
                  <FontAwesomeIcon
                    icon={faEye}
                    title="Preview"
                    className="previewHero"
                  />{" "}
                </Link>

                <FontAwesomeIcon
                  onClick={() => handleDelete(item.id)}
                  icon={faTrashCan}
                  className="deleteHero"
                  title="Delete"
                />
              </div>
              <div className="heroData">
                <div>{item.name}</div>
                <div>{item.displayName}</div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </>
  );
};

export default HeroesList;
