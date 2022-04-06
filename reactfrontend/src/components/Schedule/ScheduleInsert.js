import { Tab, TabList, TabPanel, TabPanels, Tabs } from "@chakra-ui/react";
import React from "react";
import ScheduleFormInsert from "./ScheduleFormInsert";
import ScheduleFormUpdate from "./ScheduleFormUpdate";

const ScheduleInsert = ({
  managementEntityId,
  setScheduleData,
  scheduleData,
  selectedScheduleId,
}) => {
  return (
    <>
      <Tabs>
        <TabList>
          <Tab>Insert</Tab>
          <Tab>Update</Tab>
        </TabList>
        <TabPanels>
          <TabPanel>
            <ScheduleFormInsert
              managementEntityId={managementEntityId}
              updateScheduleData={setScheduleData}
              graphScheduleData={scheduleData}
            />
          </TabPanel>
          <TabPanel>
            <ScheduleFormUpdate
              managementEntityId={managementEntityId}
              updateScheduleData={setScheduleData}
              graphScheduleData={scheduleData}
              selectedScheduleId={selectedScheduleId}
            />
          </TabPanel>
        </TabPanels>
      </Tabs>
    </>
  );
};

export default ScheduleInsert;
