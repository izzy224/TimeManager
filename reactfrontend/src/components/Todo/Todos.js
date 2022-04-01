import { Flex } from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import Sidebar from "../Sidebar";
import Board from "react-trello";
import Cookies from "js-cookie";

const data = {
  lanes: [
    {
      id: "lane1",
      title: "Planned Tasks",
      label: "2/2",
      cards: [
        {
          id: "Card1",
          title: "Write Blog",
          description: "Can AI make memes",
          label: "30 mins",
          draggable: false,
        },
        {
          id: "Card2",
          title: "Pay Rent",
          description: "Transfer via NEFT",
          label: "5 mins",
          metadata: { sha: "be312a1" },
        },
      ],
    },
    {
      id: "lane2",
      title: "Completed",
      label: "0/0",
      cards: [],
    },
  ],
};

const dataTemplate = {
  lanes: [{}],
};

const Todos = () => {
  const [boardData, setBoardData] = useState(dataTemplate);
  const [managementEntityId, setManagementEntityId] = useState(Number);
  useEffect(() => {
    const date = new Date();
    fetch("/api/todo/get", {
      method: "POST",
      headers: {
        Authorization: window.sessionStorage.getItem("token"),
        "Content-type": "application/json",
      },
      body: JSON.stringify({ date: date.toDateString() }),
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
        let tempBoardData = { lanes: [] };
        data.todos.map((statusList) => {
          tempBoardData.lanes.push({
            id: `${statusList.toDoStatus.toDoStatusId}`,
            title: statusList.toDoStatus.name,
            cards: statusList.todos.map((todo) => {
              return {
                id: `${todo.toDoId}`,
                title: todo.name,
                description: todo.description,
              };
            }),
          });
        });
        setBoardData(tempBoardData);
        setManagementEntityId(data.managementEntityId);
      });
  }, []);

  const addCard = (card, laneId) => {
    console.log(card);
    console.log(laneId);
    let toDoObject = {
      ManagementEntityId: managementEntityId,
      ToDoStatusId: laneId,
      Name: card.title,
      Description: card.description,
    };
    fetch("/api/todo", {
      method: "POST",
      headers: {
        Authorization: window.sessionStorage.getItem("token"),
        "Content-type": "application/json",
      },
      body: JSON.stringify(toDoObject),
    })
      .then((response) => response.json)
      .then((data) => {
        console.log(data);
      });
  };

  return (
    <>
      <Flex>
        <Sidebar />
        <Board
          editable
          draggable
          style={{ height: "94vh", width: "100%" }}
          data={boardData}
          onCardAdd={addCard}
        />
      </Flex>
    </>
  );
};

export default Todos;
