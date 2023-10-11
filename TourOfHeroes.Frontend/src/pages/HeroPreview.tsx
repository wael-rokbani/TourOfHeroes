import { useContext, useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Hero, HeroesService } from "../generated";
import { AppContext } from "../AppContext";

type heroParams = { id: string | undefined };

export const HeroPreview = () => {
  const initialHeroValues: Hero = {
    id: 0,
    displayName: "",
    name: "",
    type: { id: 1, name: "" },
  };
  const { id } = useParams<heroParams>();
  const heroId: number = Number(id);
  const isNew: boolean = isNaN(heroId);

  const [hero, setHero] = useState<Hero>(initialHeroValues);

  const navigate = useNavigate();

  const { lastViewedHeroes, setLastViewedHeroes } = useContext(AppContext);

  //const { lastViewedHeroes, setLastViewedHeroes} = useContext(AppContext);

  useEffect(() => {
    const loadData = async () => {
      const result = await HeroesService.getApiV1Heroes1(heroId);
      setHero(result);

      setLastViewedHeroes([result, ...lastViewedHeroes]);
    };

    if (!isNew) loadData();
  }, [heroId]);

  const handleSave = async () => {
    //todo validation

    let upsertResult;

    if (isNew) upsertResult = await HeroesService.postApiV1Heroes(hero);
    else upsertResult = await HeroesService.putApiV1Heroes(hero.id!, hero);

    if (upsertResult != null) navigate(`/Heroes/${upsertResult.id}`);
  };

  return (
    <>
      <h2 className="title">{isNew ? "New Hero" : "Hero Details"}</h2>
      <div>
        <div>
          <input
            placeholder="Hero Name"
            name="name"
            value={hero.name}
            onChange={(e) => setHero({ ...hero, name: e.target.value })}
          />
        </div>
        <div>
          <input
            placeholder="Hero Identity"
            name="displayName"
            value={hero.displayName}
            onChange={(e) => setHero({ ...hero, displayName: e.target.value })}
          />
        </div>
        <div>
          <select
            className="typeSelect"
            value={hero.type?.id}
            onChange={(e) =>
              setHero({
                ...hero,
                type: { id: Number(e.target.value), name: "" },
              })
            }
          >
            <option value={1}>Marvel</option>
            <option value={2}>DC</option>
          </select>
        </div>
        <div>
          <button className="btn" onClick={() => navigate("/Heroes")}>
            Cancel
          </button>
          <button className="btn" onClick={handleSave}>
            Save
          </button>
        </div>
      </div>
    </>
  );
};
