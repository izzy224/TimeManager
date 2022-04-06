import { Flex } from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import Sidebar from "../Sidebar";
import ScheduleGraph from "./ScheduleGraph";
import ScheduleInsert from "./ScheduleInsert";
const Schedule = () => {
  const [scheduleData, setScheduleData] = useState([]);
  const [managementEntityId, setManagementEntityId] = useState([]);
  const [selectedScheduleId, setSelectedScheduleId] = useState(Number);
  useEffect(() => {
    const date = new Date();
    fetch("/api/schedule/get", {
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
        setScheduleData(data.schedules);
        setManagementEntityId(data.managementEntityId);
      });
  }, []);
  useEffect(() => {
    console.log(selectedScheduleId);
  }, [selectedScheduleId]);

  return (
    <>
      <Flex h="94vh" w="100vw">
        <Sidebar w="15vw" />
        <ScheduleGraph
          graphData={scheduleData}
          setSelectedScheduleId={setSelectedScheduleId}
          w="65vw"
        ></ScheduleGraph>
        <ScheduleInsert
          managementEntityId={managementEntityId}
          setScheduleData={setScheduleData}
          scheduleData={scheduleData}
          selectedScheduleId={selectedScheduleId}
          w="20vw"
        ></ScheduleInsert>
      </Flex>
    </>
  );
};

export default Schedule;
