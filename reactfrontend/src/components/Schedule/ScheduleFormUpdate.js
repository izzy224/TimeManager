import React, { useEffect, useState } from "react";
import {
  Text,
  Flex,
  Box,
  FormControl,
  FormLabel,
  Input,
  Button,
  NumberInput,
  NumberInputField,
  NumberInputStepper,
  NumberIncrementStepper,
  NumberDecrementStepper,
} from "@chakra-ui/react";
const form = {
  Name: String,
  Description: String,
  StartTimeHours: Number,
  StartTimeMinutes: Number,
  EndTimeHours: Number,
  EndTimeMinutes: Number,
};

const ScheduleFormUpdate = ({
  managementEntityId,
  updateScheduleData,
  graphScheduleData,
  selectedScheduleId,
}) => {
  const [scheduleData, setScheduleData] = useState({ ...form });
  useEffect(() => {
    let selectedObj = graphScheduleData.find((sched) => {
      return sched.timeScheduleId == selectedScheduleId;
    });
    if (selectedObj !== undefined) {
      let tempObj = form;
      let startTime = new Date(selectedObj.startTime);
      let endTime = new Date(selectedObj.endTime);
      tempObj.Name = selectedObj.name;
      tempObj.Description = selectedObj.description;
      tempObj.StartTimeHours = startTime.getHours();
      tempObj.StartTimeMinutes = startTime.getMinutes();
      tempObj.EndTimeHours = endTime.getHours();
      tempObj.EndTimeMinutes = endTime.getMinutes();
      setScheduleData(tempObj);
    }
  }, [selectedScheduleId]);
  const handleSubmit = () => {
    let startTime = new Date();
    let endTime = new Date();
    startTime.setHours(scheduleData.StartTimeHours);
    startTime.setMinutes(scheduleData.StartTimeMinutes);
    endTime.setHours(scheduleData.EndTimeHours);
    endTime.setMinutes(scheduleData.EndTimeMinutes);

    let fetchObject = {
      TimeScheduleId: selectedScheduleId,
      ManagementEntityId: managementEntityId,
      Name: scheduleData.Name,
      Description: scheduleData.Description,
      StartTime: startTime.toISOString(),
      EndTime: endTime.toISOString(),
    };
    fetch("api/schedule", {
      method: "PUT",
      headers: {
        Authorization: window.sessionStorage.getItem("token"),
        "Content-type": "application/json",
      },
      body: JSON.stringify(fetchObject),
    })
      .then((response) => response.json())
      .then((data) => {});
  };

  const handleDelete = () => {
    fetch("api/schedule", {
      method: "DELETE",
      headers: {
        Authorization: window.sessionStorage.getItem("token"),
        "Content-type": "application/json",
      },
      body: JSON.stringify(selectedScheduleId),
    })
      .then((response) => response.json())
      .then((data) => {});
  };
  return (
    <>
      <Flex mt="5" width="full" justifyContent="end" alignItems="top">
        <Box
          p="8"
          maxWidth="1000px"
          borderWidth="1"
          borderRadius="12"
          boxShadow="lg"
        >
          <Box textAlign="center">
            <Box my="4" textAlign="left"></Box>
            <form onSubmit={handleSubmit}>
              <FormControl isRequired>
                <FormLabel>Name</FormLabel>
                <Input
                  type="text"
                  onChange={(event) =>
                    setScheduleData({
                      ...scheduleData,
                      Name: event.currentTarget.value,
                    })
                  }
                  value={scheduleData.Name}
                />
              </FormControl>

              <FormControl isRequired>
                <FormLabel>Description</FormLabel>
                <Input
                  type="text"
                  onChange={(event) =>
                    setScheduleData({
                      ...scheduleData,
                      Description: event.currentTarget.value,
                    })
                  }
                  value={scheduleData.Description}
                />
              </FormControl>
              <Flex>
                <FormControl isRequired>
                  <FormLabel>Start time</FormLabel>
                  <Flex>
                    <NumberInput
                      min="0"
                      max="23"
                      step={1}
                      px="0"
                      w="30%"
                      onChange={(value) =>
                        setScheduleData({
                          ...scheduleData,
                          StartTimeHours: value,
                        })
                      }
                      value={scheduleData.StartTimeHours}
                    >
                      <NumberInputField />
                      <NumberInputStepper>
                        <NumberIncrementStepper />
                        <NumberDecrementStepper />
                      </NumberInputStepper>
                    </NumberInput>
                    <Text mx="5px" fontSize="xl">
                      :
                    </Text>
                    <NumberInput
                      min="0"
                      max="59"
                      step={5}
                      px="0"
                      w="30%"
                      onChange={(value) =>
                        setScheduleData({
                          ...scheduleData,
                          StartTimeMinutes: value,
                        })
                      }
                      value={scheduleData.StartTimeMinutes}
                    >
                      <NumberInputField />
                      <NumberInputStepper>
                        <NumberIncrementStepper />
                        <NumberDecrementStepper />
                      </NumberInputStepper>
                    </NumberInput>
                  </Flex>
                </FormControl>
              </Flex>
              <Flex>
                <FormControl isRequired>
                  <FormLabel>End time</FormLabel>
                  <Flex>
                    <NumberInput
                      min="0"
                      max="23"
                      step={1}
                      px="0"
                      w="30%"
                      onChange={(value) =>
                        setScheduleData({
                          ...scheduleData,
                          EndTimeHours: value,
                        })
                      }
                      value={scheduleData.EndTimeHours}
                    >
                      <NumberInputField />
                      <NumberInputStepper>
                        <NumberIncrementStepper />
                        <NumberDecrementStepper />
                      </NumberInputStepper>
                    </NumberInput>
                    <Text mx="5px" fontSize="xl">
                      :
                    </Text>
                    <NumberInput
                      min="0"
                      max="59"
                      step={5}
                      px="0"
                      w="30%"
                      onChange={(value) =>
                        setScheduleData({
                          ...scheduleData,
                          EndTimeMinutes: value,
                        })
                      }
                      value={scheduleData.EndTimeMinutes}
                    >
                      <NumberInputField />
                      <NumberInputStepper>
                        <NumberIncrementStepper />
                        <NumberDecrementStepper />
                      </NumberInputStepper>
                    </NumberInput>
                  </Flex>
                </FormControl>
              </Flex>
              <Button width="full" mt={4} type="submit">
                Update
              </Button>
              <Button width="full" mt={4} type="button" onClick={handleDelete}>
                Delete
              </Button>
            </form>
          </Box>
        </Box>
      </Flex>
    </>
  );
};

export default ScheduleFormUpdate;
