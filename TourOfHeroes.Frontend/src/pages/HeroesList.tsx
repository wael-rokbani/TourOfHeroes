import { useState, useEffect } from "react"
import { Hero, HeroesService } from "../generated"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faAddressBook } from "@fortawesome/free-regular-svg-icons";
import { faEye } from "@fortawesome/free-regular-svg-icons/faEye";
import { faTrashCan } from "@fortawesome/free-regular-svg-icons/faTrashCan";

const HeroesList = () => {

  const [heroes, setHeroes] = useState<Hero[]>([]);
 
  useEffect(() => {
   
    const loadData = async () => {
      const result = await HeroesService.getApiV1Heroes();
      setHeroes(result);
    }
    
    loadData();
  
  }, [])
  
  
  return (
    <>
    <h2 className="title">Heroes List</h2>

    <div className="pageContent">

    {heroes.length === 0 ? <span>Aucune donnée</span> : ""}

    <div className="heroesList">
    
    {heroes.map((item) => (

    <div className="heroItem" key={item.id}>
      <div className="actions">
        <FontAwesomeIcon icon={faEye} />
        <FontAwesomeIcon icon={faTrashCan} />
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
  )
}

export default HeroesList