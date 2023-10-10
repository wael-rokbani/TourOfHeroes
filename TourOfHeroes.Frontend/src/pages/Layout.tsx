import { Outlet, Link } from "react-router-dom";

export default function Layout() {
  return (
    <div className="layoutContainer">
      <div className="sideBar">
        <nav>
          <ul>
            <li>
              <Link to="/">Dashboard</Link>
            </li>
            <li>
              <Link to="/Heroes">Heroes list</Link>
            </li>
          </ul>
        </nav>
      </div>
      <div className="mainContainer">
        <Outlet />
      </div>
    </div>
  );
}
